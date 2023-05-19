namespace Common.Validators
{
    public abstract class BaseDtoValidator<T> : AbstractValidator<T>
    where T : BaseDto
    {
        public BaseDtoValidator()
        {
        }
    }
}
