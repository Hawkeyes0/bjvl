using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Net.Bjvl.Models
{
    [TableAttribute("Config")]
    public class Config
    {
		[Key]
		public int Id {get;set;}

		public string Title {get;set;}

		public string Name {get;set;}

		public string Value {get;set;}

		public string Values {get;set;}

		public string Data {get;set;}

		public string Form {get;set;}

		public string Description {get;set;}

		public int Order {get;set;}

		public int Tab {get;set;}
    }
}