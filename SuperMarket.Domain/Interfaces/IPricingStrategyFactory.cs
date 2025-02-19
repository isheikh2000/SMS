using SuperMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Domain.Interfaces
{
    public interface IPricingStrategyFactory
    {
        IPricingStrategy GetPricingStrategy(Product productPrice);
    }
}
