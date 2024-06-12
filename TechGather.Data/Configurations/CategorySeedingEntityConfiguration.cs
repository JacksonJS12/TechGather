namespace TechGather.Data.Configurations
{
    using Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CategorySeederEntityConfiguration : IEntityTypeConfiguration<Category>

    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(this.GenerateCategories());
        }

        private Category[] GenerateCategories()
        {
            ICollection<Category> categories = new HashSet<Category>();

            Category category = new Category();

            category = new Category()
            {
                Id = 1,
                Name = "Conference"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 2,
                Name = "Training"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 3,
                Name = "Workshop"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 4,
                Name = "Other"
            };
            categories.Add(category);

            return categories.ToArray();
        }
    }
}