using System.Collections.Generic;

namespace Models.Abstractions
{
    public abstract class BasePayload
    {
        protected BasePayload(IReadOnlyList<UserError>? errors = null)
        {
            Errors = errors;
        }

        public IReadOnlyList<UserError>? Errors { get; }
    }
}