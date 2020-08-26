using Infrastructure.Models;
using System;
using System.Collections.Generic;

namespace Infrastructure.Repositories
{
    public class CampaignRepository : RepositoryBase<string, Campaign>, ICampaignRepository
    {
        private List<Cart> _carts = new List<Cart>();

        public CampaignRepository()
        {

        }
    }
}