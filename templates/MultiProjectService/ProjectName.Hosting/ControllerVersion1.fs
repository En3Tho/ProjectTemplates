namespace ProjectName.Hosting

open System.Threading.Tasks
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open ProjectName.Contracts.Version1
open ProjectName.Domain
open ProjectName.CrossCutting

type ProjectNameVersion1(logger: ProjectNameVersion1 ILogger) =

    member this.ExampleMethod() =
        Example.makeObj()
        |> Example.toDto
        |> ValueTask.FromResult

    interface IProjectName with
        member this.ExampleMethod() = this.ExampleMethod()

[<Route(Routes.Controller)>]
type ExampleController(service: IProjectName, logger: ILogger<ExampleController>) =
   inherit ControllerBase()

   [<HttpGet(Routes.ExampleMethod)>]
   member _.GetRandomImportantData() =
      service.ExampleMethod()