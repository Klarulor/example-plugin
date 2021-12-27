using Qurre.API.Addons;
namespace example
{
    public class Config : IConfig
    {
        public string Name { get; set; } = "example-plugin";
        [System.ComponentModel.Description("yes, this is the description of the description")]
        public string Description { get; set; } = "This is an example of creating a custom configuration for a plugin.";
        [System.ComponentModel.Description("Welcome Text")]
        public string Welcome { get; set; } = "\n<color=#00fffb>Welcome</color>\n<color=#09ff00>Enjoy game!</color>";
    }
}