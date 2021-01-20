namespace AloneCoreApp.Infrastructure.SharedKernel
{
    public abstract class DomainEntities<T>
    {
        public T Id { get; set; }

        /// <summary>
        /// True if domain entity has an identity
        /// </summary>
        /// <returns></returns>
        public bool IsTransient()
        {
            return Id.Equals(default(T));
        }
    }
}