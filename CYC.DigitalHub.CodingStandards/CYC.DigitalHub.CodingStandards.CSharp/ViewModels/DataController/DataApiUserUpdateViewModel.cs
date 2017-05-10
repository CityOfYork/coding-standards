using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CYC.DigitalHub.CodingStandards.CSharp.ViewModels.DataController
{
    // View models for specific cases should inherit the base view model and override required properties.
    public class DataApiUserUpdateViewModel : DataApiUserViewModel
    {
        // Id cannot be 0
        [Range(1, int.MaxValue)]
        public override int Id { get; set; }
    }
}
