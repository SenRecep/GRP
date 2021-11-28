using AutoMapper;

using GRP.Services.Company.Models.DTO;
using GRP.Shared.BLL.Interfaces;
using GRP.Shared.Core.ExtensionMethods;
using GRP.Shared.Core.Response;
using GRP.Shared.Core.Services.Interfaces;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GRP.Services.Company.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompaniesController : ControllerBase
    {
        private readonly IGenericQueryService<Models.Company> queryService;
        private readonly IGenericCommandService<Models.Company> commandService;
        private readonly ISharedIdentityService sharedIdentityService;
        private readonly IMapper mapper;
        private readonly ILogger<CompaniesController> logger;

        public CompaniesController(
            IGenericQueryService<Models.Company> queryService,
            IGenericCommandService<Models.Company> commandService,
            ISharedIdentityService sharedIdentityService,
            IMapper mapper,
            ILogger<CompaniesController> logger)
        {
            this.queryService = queryService;
            this.commandService = commandService;
            this.sharedIdentityService = sharedIdentityService;
            this.mapper = mapper;
            this.logger = logger;
        }
        ///<summary>
        ///Bütün ürünleri getirme.
        ///</summary>  
        ///<response code="200">Başarıyla gerçekleşti.</response>      
        [HttpGet]
        //[AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var data = await queryService.GetAllAsync<ListDto>();
            logger.LogInformation("api/companies/getall calling enpoint");
            return Response<IEnumerable<ListDto>>.Success(data, StatusCodes.Status200OK).CreateResponseInstance();
        }
        ///<summary>
        ///Id bilgisi verilen ürünü getirme.
        ///</summary>  
        ///<response code="200">Başarıyla gerçekleşti.</response>
        ///<response code="404">Ürün bulunamadı.</response>
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var data = await queryService.GetByIdAsync<ListDto>(id);
            logger.LogInformation("api/companies/GetById calling enpoint");
            if (data.IsNull())
            {
                logger.LogInformation("company not found");
                return Response<NoContent>.Fail(
                    statusCode: StatusCodes.Status404NotFound,
                    isShow: true,
                    path: "api/companies/GetById",
                    errors: "İstenilen şirket bulunamadı"
                    ).CreateResponseInstance();
            }
            return Response<ListDto>.Success(data, StatusCodes.Status200OK).CreateResponseInstance();
        }
        ///<summary>
        ///Ürün oluşturma.
        ///</summary>  
        ///<response code="201">Başarıyla eklendi.</response>
        ///<response code="400">Dosya bulunamadı ya da desteklenmiyor.</response>
        ///<response code="500">Ürün resmi yüklenirken hata ile karşılaşıldı</response>
        [HttpPost()]
        public async Task<IActionResult> Post(CreateDto dto)
        {
            dto.CreatedUserId = Guid.Parse(sharedIdentityService.GetUserId);
            Models.Company result = await commandService.AddAsync(dto);
            await commandService.Commit();
            logger.LogInformation($"api/companies/add calling enpoint");
            return Response<ListDto>.Success(mapper.Map<ListDto>(result), StatusCodes.Status201Created).CreateResponseInstance();
        }
        ///<summary>
        ///Ürün güncelleme.
        ///</summary>  
        ///<response code="204">Başarıyla güncellendi.</response>
        [HttpPut]
        public async Task<IActionResult> Put(UpdateDto dto)
        {
            dto.UpdatedUserId = Guid.Parse(sharedIdentityService.GetUserId);
            await commandService.UpdateAsync(dto);
            await commandService.Commit();
            logger.LogInformation($"api/companies/update calling enpoint");
            return Response<NoContent>.Success(StatusCodes.Status204NoContent).CreateResponseInstance();
        }

        ///<summary>
        ///Id bilgisi verilen ürünü silme.
        ///</summary>  
        ///<response code="204">Başarıyla silindi.</response>
        ///<response code="404">Ürün bulunamadı.</response>
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var data = await queryService.GetByIdAsync<DeleteDto>(id);
            data.UpdatedUserId = Guid.Parse(sharedIdentityService.GetUserId);
            logger.LogInformation("api/companies/delete calling enpoint");
            if (data.IsNull())
            {
                logger.LogInformation("company not found");
                return Response<NoContent>.Fail(
                    statusCode: StatusCodes.Status404NotFound,
                    isShow: true,
                    path: "api/companies/delete",
                    errors: "İstenilen ürün bulunamadı"
                    ).CreateResponseInstance();
            }

            await commandService.RemoveAsync(data);
            await commandService.Commit();

           return Response<NoContent>.Success(StatusCodes.Status204NoContent).CreateResponseInstance();
        }
    }
}
