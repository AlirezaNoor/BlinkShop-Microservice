using BlicnkShop.Service.Athu.Api.model;
using Microsoft.AspNetCore.Identity;

namespace BlicnkShop.Service.Athu.Api.Service.IService;

public interface IGwtgenerator
{

    string GwrCreator(IdentityUser user,IEnumerable<string> role);

}