using System;
using System.Collections.Generic;
using System.Linq;
using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class CategoryInMemoryRepository : ICategoryRepository
    {
        private List<Category> categories;

        public CategoryInMemoryRepository() //Depois substituir por database
        {
            categories = new List<Category>
            {
                new Category
                {
                    CategoryId = 1,
                    Name = "Beverage",
                    Description = "Beverage"

                },
                 new Category
                {
                    CategoryId = 2,
                    Name = "Bakery",
                    Description = "Bakery"

                },
                  new Category
                {
                    CategoryId = 3,
                    Name = "Meate",
                    Description = "Meat"

                }
            };
        }

        public void AddCategory(Category category)
        {
            if (categories.Any(x => x.Name.Equals(category.Name,StringComparison.OrdinalIgnoreCase)))
            {
                return;
            }
            var maxId = categories.Any() ? categories.Max(x => x.CategoryId) : 0;
            category.CategoryId = maxId + 1;


            categories.Add(category);
        }

        public void DeleteCategory(int categoryId)
        {
            var categoryToDelete = GetCategoryById(categoryId);
            categories.Remove(categoryToDelete);
        }

        public IEnumerable<Category> GetCategories()
        {
            return categories;
        }

        public Category GetCategoryById(int categoryId)
        {
            return categories.Find(x => x.CategoryId == categoryId);
        }

        public void UpdateCategory(Category category)
        {
            //categories?.FirstOrDefault(x => x.CategoryId == category.CategoryId)
            var categoryToUpdate = GetCategoryById(category.CategoryId);
            if (categoryToUpdate != null)
            {
                categoryToUpdate.Name = category.Name;
                categoryToUpdate.Description = category.Description;

            }
        }
    }
}
