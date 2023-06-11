using System.Collections.Generic;

namespace Hunty.Chat.Transverse.Models.Response.Error
{
    public class InvalidFieldModel
    {
        public string Field { get; set; }
        public List<string> Errors { get; set; }
    }
}
