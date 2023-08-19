using System.Runtime.Serialization;

namespace Lafise.SEGMIntegration.Api.Models.v1
{
    /// <summary>
    /// Entity to receive a todo object from the client
    /// </summary>
    public class UpdateTodoJson
    {
        /// <summary>
        /// The name of the todo
        /// </summary>
        [DataMember(Name = "name")]
        public string? Name { get; set; }

        /// <summary>
        /// Description associated to the todo
        /// </summary>
        [DataMember(Name = "description")]
        public string? Description { get; set; }

        /// <summary>
        /// Version of the todo
        /// </summary>
        [DataMember(Name = "version")]
        public float Version { get; set; }
    }
}
