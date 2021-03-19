using System.Linq;
using System;
using GraphQL_API.Entities;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;

namespace GraphQL_API.GraphQL
{
  public class FactInterventionQuery : ObjectGraphType
  {
    public FactInterventionQuery(warehouse_developmentContext db, RailsApp_development_dbContext _db)
    {
      Field<FactInterventionsType>(
        "interventionQuery",

        arguments: new QueryArguments(
          new QueryArgument<IdGraphType> { Name = "id"}),

        resolve: context =>
        {
          var id = context.GetArgument<long>("id");
          var intervention = db
            .FactInterventions
            .FirstOrDefault(i => i.Id == id);

          return intervention;
        });

        Field<EmployeesType>(
        "employeeQuery",

        arguments: new QueryArguments(
          new QueryArgument<IdGraphType> { Name = "id"}),

        resolve: context =>
        {
          var id = context.GetArgument<long>("id");
          var employee = _db
            .Employee
            .ToListAsync();

          return employee;
        });

        Field<ListGraphType<EmployeesType>>(
        "allemployeesQuery",

        //arguments:// new QueryArguments(
        //  new QueryArgument<IdGraphType> { Name = "id"}),

        resolve: context =>
        {
          //var id = context.GetArgument<long>("id");
          var employees = _db
            .Employee
            .ToListAsync();

          return employees;
        });

        Field<BuildingsType>(
        "buildingQuery",

        arguments: new QueryArguments(
          new QueryArgument<IdGraphType> { Name = "id"}),

        resolve: context =>
        {
          var id = context.GetArgument<long>("id");
          var building = _db
            .Building
            .Include(x => x.Address)
            //.Include(x => x.Customer)
            .FirstOrDefault(i => i.Id == id);

          return building;
        });

        Field<ListGraphType<ElevatorsType>>(
        "elevatorQuery",

        arguments: new QueryArguments(
          new QueryArgument<IdGraphType> { Name = "id"}),

        resolve: context =>
        {
          var id = context.GetArgument<long>("id");
          var elevators = _db
            .Elevator
            .Where(_=>_.column_id == id)
                            .ToListAsync();

          return elevators;
        });

        Field<ListGraphType<ColumnsType>>(
        "columnQuery",

        arguments: new QueryArguments(
          new QueryArgument<IdGraphType> { Name = "id"}),

        resolve: context =>
        {
          var id = context.GetArgument<long>("id");
          var columns = _db
            .Column
            .Where(_=>_.battery_id == id)
                            .ToListAsync();

          return columns;
        });

        Field<ListGraphType<BatteriesType>>(
        "batteriesQuery",

        arguments: new QueryArguments(
          new QueryArgument<IdGraphType> { Name = "id"}),

        resolve: context =>
        {
          var id = context.GetArgument<long>("id");
          var batteries = _db
            .Battery
            .Where(_=>_.building_id == id)
                            .ToListAsync();

          return batteries;
        });

        Field<CustomersType>(
        "customerQuery",

        arguments: new QueryArguments(
          new QueryArgument<IdGraphType> { Name = "id"}),

        resolve: context =>
        {
          var id = context.GetArgument<long>("id");
          var customers = _db
            .Customer
            .FirstOrDefault(i => i.Id == id);

          return customers;
        });

    }
  }
}