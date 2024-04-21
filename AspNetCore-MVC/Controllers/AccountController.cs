using AspNetCore_MVC.ViewModels;
using AspNetCore_MVC.ViewModels.Account;
using Infrastructure.Entites;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Net.NetworkInformation;
using System.Security.Principal;

namespace AspNetCore_MVC.Controllers;
[Authorize]
public class AccountController(UserManager<UserEntity> userManager, AddressService addressService) : Controller
{
    private readonly UserManager<UserEntity> _userManager = userManager;
    private readonly AddressService _addressService = addressService;


    #region Details
    [HttpGet]
    [Route("/auth/details")]


    public async Task<IActionResult> Details()
    {
       


        var viewModel = new AccountDetailsViewModel();
        viewModel.ProfileInfo = await PopulareProfileInfoAsyns();
        viewModel.BasicInfoForm ??= await PopulareBasicInfoAsyns();
        viewModel.AddressInfoForm ??= await PopulareAddressInfoAsyns();
        return View(viewModel);
    }

    #endregion


    #region [HttpPost] Details
    [HttpPost]
    [Route("/auth/details")]


    public async Task<IActionResult> Details(AccountDetailsViewModel viewModel)
    {
        if (viewModel.BasicInfoForm != null)
        {
            if (viewModel.BasicInfoForm.FirstName != null && viewModel.BasicInfoForm.LastName != null && viewModel.BasicInfoForm.Email != null)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user != null)
                {
                    user.FirstName = viewModel.BasicInfoForm.FirstName;
                    user.LastName = viewModel.BasicInfoForm.LastName;
                    user.Email = viewModel.BasicInfoForm.Email;
                    user.PhoneNumber = viewModel.BasicInfoForm.Phone;
                    var result = await _userManager.UpdateAsync(user);
                    if (!result.Succeeded)
                    {
                        ModelState.AddModelError("AlreadyExists", "Samthing was wrong,,, Unble to save data");
                        ViewData["ErrorMessage"] = "Samthing was wrong";

                    }
                }
            }


        }
        if (viewModel.AddressInfoForm != null)
        {
            if (viewModel.AddressInfoForm.AddressLine_1 != null && viewModel.AddressInfoForm.PostalCode != null && viewModel.AddressInfoForm.City != null)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user != null)
                {
                    var address = await _addressService.GetAddressAsync(user.Id);
                    if (address != null)
                    {
                        address.AddressLine_1 = viewModel.AddressInfoForm.AddressLine_1;
                        address.PostalCode = viewModel.AddressInfoForm.PostalCode;
                        address.City = viewModel.AddressInfoForm.City;

                        var updateAddressResult = await _addressService.UpdateAddressAsync(address);
                        if (!updateAddressResult)
                        {
                            ModelState.AddModelError("AlreadyExists", "Something was wrong, Unable to save data");
                            ViewData["ErrorMessage"] = "Something was wrong, Unable to save update address";
                        }

                    }
                    else
                    {
                        address = new AddressEntity
                        {
                            UserId = user.Id,
                            AddressLine_1 = viewModel.AddressInfoForm.AddressLine_1,
                            PostalCode = viewModel.AddressInfoForm.PostalCode,
                            City = viewModel.AddressInfoForm.City
                        };
                        var createAddressResult = await _addressService.CreateAddressAsync(address);
                        if (!createAddressResult)
                        {
                            ModelState.AddModelError("AlreadyExists", "Something was wrong, Unable to save data");
                            ViewData["ErrorMessage"] = "Something was wrong, Unable to save update address";
                        }

                    }

                    var updateUserResult = await _userManager.UpdateAsync(user);
                    if (!updateUserResult.Succeeded)
                    {
                        ModelState.AddModelError("AlreadyExists", "Something was wrong, Unable to save data");
                        ViewData["ErrorMessage"] = "Something was wrong";
                    }
                }
            }
        }


        viewModel.ProfileInfo = await PopulareProfileInfoAsyns();
        viewModel.BasicInfoForm ??= await PopulareBasicInfoAsyns();
        viewModel.AddressInfoForm ??= await PopulareAddressInfoAsyns();

        return View(viewModel);
    }

    #endregion






    private async Task<BasicInfoViewModel> PopulareBasicInfoAsyns()
    {
        var user = await _userManager.GetUserAsync(User);
        return new BasicInfoViewModel
        {
            UserId = user!.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email!,
            Phone = user.PhoneNumber,

        };
    }



    private async Task<ProfileInfoViewModel> PopulareProfileInfoAsyns()
    {
        var user = await _userManager.GetUserAsync(User);
        return new ProfileInfoViewModel
        {

            FirstName = user!.FirstName,
            LastName = user.LastName,
            Email = user.Email!,


        };
    }

    private async Task<AddressInfoViewModel> PopulareAddressInfoAsyns()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user != null)
        {
            var address = await _addressService.GetAddressAsync(user.Id);
            if (address != null)
            {
                return new AddressInfoViewModel
                {
                    AddressLine_1 = address.AddressLine_1,
                    PostalCode = address.PostalCode,
                    City = address.City
                };
            }
        }

       
        return new AddressInfoViewModel();
    }



    #region [HttpPost] SaveBasicInfo
    [HttpPost]


    public IActionResult SaveBasicInfo(AccountDetailsViewModel viewModel)
    {
        if (TryValidateModel(viewModel.BasicInfoForm))
        {
            return RedirectToAction("Home", "Default");
        }
        return View("Details", viewModel);
    }
    #endregion

    #region SaveAddressInfo
    public IActionResult SaveAddressInfo(AccountDetailsViewModel viewModel)
    {
        if (TryValidateModel(viewModel.AddressInfoForm))
        {
            return RedirectToAction("Home", "Default");
        }
        return View("Details", viewModel);
    }
    #endregion



    [HttpPost]
    public async Task<IActionResult> UploadProfileImage(IFormFile file)
    {
        var user = await _userManager.GetUserAsync(User);

        if (user != null && file != null && file.Length != 0)
        {
            var filename = $"p_{user.Id}_{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/uploads/profiles", filename);

            using var fs = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(fs);

            user.ProfileImage = filename;
            await _userManager.UpdateAsync(user);
        }
        else
        {
            TempData["StatusMessage"] = "Unable to upload profile image.";
        }
        return RedirectToAction("Details", "Account");
    }
}