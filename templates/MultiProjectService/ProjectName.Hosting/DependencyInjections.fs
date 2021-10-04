namespace ProjectName.Hosting.DependencyInjections

open System.Runtime.CompilerServices
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.DependencyInjection
open ProjectName.Contracts.Version1
open ProjectName.Hosting

[<Extension; AbstractClass>]
type DependencyInjectionExtensions() =

    [<Extension>]
    static member AddProjectName(services: IServiceCollection) =
        services.AddSingleton<IProjectName, ProjectNameVersion1>()

    [<Extension>]
    static member AddExampleController(builder: IMvcBuilder) =
        builder.AddApplicationPart(typeof<ExampleController>.Assembly)