using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheetaBeer.Services;

public interface IBeerService
{
    IAsyncEnumerable<Beer> GetBeersAsync();
}