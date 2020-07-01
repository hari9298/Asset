using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace Asset.Model.UserAdmin
{
    public static class LoginDTO
    {
        public static Login ConvertToDTOLogin(this Login login)
        {
            return new Login
            {
               
                loginName = login.loginName,
                Password = login.Password,
                Token = login.Token,
                MenuNavigation = null
            };
        }
        public static List<Login> ConvertToDTOLoginList(this List<Login> loginss)
        {
            return loginss.Select(lgn => lgn.ConvertToDTOLogin()).ToList();
        }

        public static Login ConvertToDTOLoginEntity(this Login login)
        {
            return new Login
            {
                loginName = login.loginName,
                Password = login.Password,
                Token = login.Token,
                userId = login.userId,
                //MenuNavigation = ConvertToDTOTreeNodeEntityList(login.MenuNavigation)
                MenuNavigation = null

            };
        }
        public static List<Login> ConvertToDTOLoginEntityList(this List<Login> loginss)
        {
            return loginss.Select(lgn => lgn.ConvertToDTOLoginEntity()).ToList();
        }

        public static TreeNode ConvertToDTOTreeNode(this TreeNode tree)
        {
            return new TreeNode
            {
                Id = tree.Id,
                Name = tree.Name,
                URI = tree.URI,
                ImgUrl = tree.ImgUrl

                        

        //Parent = ConvertToDTOTreeNodeList(tree.Parent),
        //Children = ConvertToDTOTreeNodeList(tree.Children)

    };
        }
        public static List<TreeNode> ConvertToDTOTreeNodeList(this List<TreeNode> treess)
        {
            return treess.Select(t => t.ConvertToDTOTreeNode()).ToList();
        }
        public static TreeNode ConvertToDTOTreeNodeEntity(this TreeNode tree)
        {
            return new TreeNode
            {
                Id = tree.Id,
                Name = tree.Name,
                URI = tree.URI,
                ImgUrl = tree.ImgUrl
                // Parent = ConvertToDTOTreeNodeEntityList(tree.Parent),
                // Children = ConvertToDTOTreeNodeEntityList(tree.Children)

            };
        }
        public static List<TreeNode> ConvertToDTOTreeNodeEntityList(this List<TreeNode> navigationList)
        {
            return navigationList.Select(tree => tree.ConvertToDTOTreeNodeEntity()).ToList();
        }
    }
}