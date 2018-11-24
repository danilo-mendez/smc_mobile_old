using System;
using System.Collections.Generic;
using System.Text;

namespace Smc.Mobile.Model
{
    public interface IValidatable
    {
        bool IsValid { get; set; }

        bool Validate(IEnumerable<IValidatable> validatables);

        //IEnumerable<ValidationFailure> Errors { get; set; }
    }
}
