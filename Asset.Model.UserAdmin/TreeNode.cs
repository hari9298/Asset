using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asset.Model.UserAdmin
{
    public class TreeNode
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string URI { get; set; }
        public string ImgUrl { get; set; }

        public TreeNode Parent { get; set; }
        public List<TreeNode> Children { get; set; }


        public static List<TreeNode> FillRecursive(List<Menu> flatObjects, int? parentId = null)
        {
            return flatObjects.Where(x => x.ParentId.Equals(parentId)).Select(item => new TreeNode
            {
                Name = item.Name,
                Id = item.Id,
                URI= item.URI,
                ImgUrl = item.MenuImagePath,
                Children = FillRecursive(flatObjects, item.Id)
            }).ToList();
        }
    }

    public class Menu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string URI { get; set; }
        public int ParentId { get; set; }
        public string loginName { get; set; }
        public string MenuImagePath { get; set; }
    }

}
