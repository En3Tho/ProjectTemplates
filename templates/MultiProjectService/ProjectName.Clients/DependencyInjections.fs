namespace ProjectName.DependencyInjections

open System.Runtime.CompilerServices
open ProjectName.Clients
open Microsoft.Extensions.DependencyInjection
open ProjectName.Contracts.Version1

[<Extension; AbstractClass>]
type DependencyInjectionExtensions() =

    [<Extension>]
    static member AddDiscriminatedUnionsHttpClient(services: IServiceCollection) =
        services.AddHttpClient<IProjectName, ProjectNameVersion1HttpClient>() |> ignore
        services