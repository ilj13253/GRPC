using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GGGYstore.ViewModel
{
    public class GameVMDto
    {
        public required int Id { get; set; }

        public required string Title { get; set; }

        public required string Description { get; set; }

        public required string Publisher { get; set; }

        public required string DateRelease { get; set; }
        /*
        public override string ToString() =>
            $"Id: {Id}, Title: {Title}, Description: {Description}, Publisher: {Publisher}, DateRelease: {DateRelease.ToString("D")}";
        */
    }
}
