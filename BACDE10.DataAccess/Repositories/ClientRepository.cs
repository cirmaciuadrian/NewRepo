using AutoMapper;
using BACDE10.BusinessLogic.Common;
using BACDE10.BusinessLogic.Contracts.Responses;
using BACDE10.BusinessLogic.Interfaces.Repositories;
using BACDE10.BusinessLogic.Models.Options;
using BACDE10.DataAccess.Contexts;
using BACDE10.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BACDE10.DataAccess.Repositories;

public class ClientRepository : IClient
{   
    private readonly DataContext _dataContext;
    private readonly IMapper _mapper;
    private readonly IOptionsMonitor<HeadersConfigSettings> _options;

    public ClientRepository(DataContext dataContext, IMapper mapper, IOptionsMonitor<HeadersConfigSettings> options)
    {
        _dataContext = dataContext;
        _mapper = mapper;
        _options = options;
    }

    public async Task<ClientResponse> GetAsync()
    {
        var response = await _dataContext.Clients.ToListAsync();
        //var courseEntity = new CourseEntity()
        //{
        //    CourseDetails = new List<CourseDetailsEntity>()
        //    {
        //        new CourseDetailsEntity(){ Detail = "asdsadasd", Type = 1}
        //    },
        //    Exercises = new List<ExerciseEntity>() {
        //        new ExerciseEntity()
        //        {
        //            Requirement =" sdsa",
        //        }
        //    },
        //    Name = "course name"
        //};
        //_dataContext.Courses.Add(courseEntity);
        //var categoryEnityt = new CategoryEntity()
        //{
        //    Name = "category name"
        //};
        //_dataContext.Categories.Add(categoryEnityt);
        //var orice = _options.CurrentValue;
        //var course = _dataContext.Courses.FirstOrDefault();
        //course.Name = "updated";

        var errorMsg = Errors.ErrorTestCuParametru("asda");
        return new ClientResponse();
    }
}
