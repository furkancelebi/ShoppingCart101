using Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Infrastructure.Models
{
    public class Category : BaseEntity
    {
        [Required(AllowEmptyStrings = false)]
        public string Title { get; }

        private Category ParentCategory { get; set; }

        public Category(string title, Category parentCategory)
        {
            Title = title;
            ParentCategory = parentCategory;

            ValidationHelper.Validate(this);
        }

        public Category(string title) : this(title, null)
        {
        }

        public void AddCampaign(Campaign campaign)
        {
            if (Campaigns.Find(x => x.Id == campaign.Id) == null)
            {
                Campaigns.Add(campaign);
            }
        }

        public List<Campaign> Campaigns { get; } = new List<Campaign>();
    }
}