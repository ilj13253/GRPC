using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GGStore.Domain.Exception
{
    public class NotFoundException(string name, object key) : System.Exception($"Entity {name} ({key}) was not found.")
    {
    }
}
