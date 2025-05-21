using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooAssignment.Models;
public class HabitatVisit
{
    public int Id { get; set; }
    public int InternalDay { get; set; }
    public int HabitatId { get; set; }
    public int PersonId { get; set; }
    public int FavoriteAnimalId { get; set; }
}
