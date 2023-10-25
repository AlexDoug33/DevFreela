using System;
using System.Collections.Generic;
using System.Text;

namespace DevFreela.Application.InputModels
{
    public class UpdateProjectInputModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal TotalCost { get; set; }
    }
}
