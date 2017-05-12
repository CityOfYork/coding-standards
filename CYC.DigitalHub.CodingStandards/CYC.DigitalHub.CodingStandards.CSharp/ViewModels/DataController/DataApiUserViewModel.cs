
using System.ComponentModel.DataAnnotations;

namespace CYC.DigitalHub.CodingStandards.CSharp.ViewModels.DataController
{
    /// <summary>
    /// View model for use in the Data Controller.
    /// </summary>
    public class DataApiUserViewModel
    {
        public virtual int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string JobTitle { get; set; }
    }
}
