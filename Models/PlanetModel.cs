using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Models
{
    public class PlanetModel
    {
        public int Id{get;set;}
        public string Name{get;set;}
        public string VName{get;set;}
        public string Content{get;set;}   
    }
}