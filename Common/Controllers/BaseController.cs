using FluentValidation.Results;

namespace Common
{
    public class BaseController<TEntity, TForCreateDto, TForReadDto, TForUpdateDto> : ControllerBase
        where TEntity : BaseEntity
        where TForCreateDto : BaseDto
        where TForReadDto : BaseDto
        where TForUpdateDto : BaseDto
    {
        protected readonly IBaseUnitOfWork<TEntity> _unitOfWork;
        protected readonly IMapper _mapper;
        protected readonly IValidator<TForCreateDto> _validatorForCreateDto;
        protected readonly IValidator<TForUpdateDto> _validatorForUpdateDto;
        protected readonly ILogger<BaseController<TEntity, TForCreateDto, TForReadDto, TForUpdateDto>> _logger;

        public BaseController(IBaseUnitOfWork<TEntity> unitOfWork,
            IMapper mapper,
            IValidator<TForCreateDto> validatorForCreateDto,
            IValidator<TForUpdateDto> validatorForUpdateDto,
            ILogger<BaseController<TEntity, TForCreateDto, TForReadDto, TForUpdateDto>> logger)

        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validatorForCreateDto = validatorForCreateDto;
            _logger = logger;
            _validatorForUpdateDto = validatorForUpdateDto;
        }

        [HttpGet]
        public virtual async Task<IEnumerable<TForReadDto>> Get()
        {
            List<TEntity> entities = await _unitOfWork.ReadAsync();
            return entities.Select(entity => _mapper.Map<TForReadDto>(entity));
        }
        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get(Guid id)
        {
            _logger.LogInformation("Get entity {userId}", id);
            TEntity entity = await _unitOfWork.ReadByIdAsync(id);
            TForReadDto entityDto = _mapper.Map<TForReadDto>(entity);
            return Ok(entityDto);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Post([FromForm] TForCreateDto entityDto)
        {
            ValidationResult validationResult = await _validatorForCreateDto.ValidateAsync(entityDto);
            if (!validationResult.IsValid)
                return BadRequest(new { errors = validationResult.Errors });

            var entity = _mapper.Map<TEntity>(entityDto);
            entity = await _unitOfWork.CreateAsync(entity);
            return Ok(_mapper.Map<TForReadDto>(entity));
        }

        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Put(Guid id, [FromForm] TForUpdateDto entityDto)
        {
            ValidationResult validationResult = await _validatorForUpdateDto.ValidateAsync(entityDto);
            if (!validationResult.IsValid) return BadRequest(new { errors = validationResult.Errors });
            var entity = await _unitOfWork.ReadByIdAsync(id);
            if (entity == null) return NotFound("Id Credential Invalid");
            entity = _mapper.Map<TEntity>(entityDto);
            entity = await _unitOfWork.UpdateAsync(entity);
            return Ok(_mapper.Map<TForReadDto>(entity));
        }

        [HttpDelete("{id}")]
        public virtual async Task Delete(Guid id)
        {
            await _unitOfWork.DeleteAsync(id);
        }
    }
}