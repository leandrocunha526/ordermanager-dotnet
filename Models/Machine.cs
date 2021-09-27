using System.ComponentModel.DataAnnotations;

namespace ordermanager_dotnet.Models
{
    public class Machine
    {
        [Required]
        public int Id {get;set;}

        [Required]
        public string Type {get;set;}

        [Required]
        public int Year {get;set;}

        [Required]
        public int ModelId {get;set;}

        public ModelMachine ModelsMachine {get;set;}
    }
}
