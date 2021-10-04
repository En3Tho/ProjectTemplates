namespace ProjectName.Domain.Client

open System
open System.Net.Http
open System.Net.Http.Json
open System.Runtime.CompilerServices
open System.Text.Json
open System.Threading.Tasks
open FSharp.Control.Tasks
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Logging
open Microsoft.Extensions.Options
open ProjectName.Contracts.Version1

[<CLIMutable>]
type ProjectNameConnectionSettings = {
    Uri: string
}

type ProjectNameVersion1HttpClient(logger: ProjectNameVersion1HttpClient ILogger,
                                              httpClient: HttpClient,
                                              jsonSerializerOptions: JsonSerializerOptions,
                                              connectionSettings: ProjectNameConnectionSettings IOptions) =

    let settings = connectionSettings.Value
    do httpClient.BaseAddress <- Uri settings.Uri

    member this.ExampleMethod() = task {
        let endPoint = Endpoints.ExampleMethod

        logger.LogTrace $"{nameof this.ExampleMethod}. Sending message to: {settings.Uri}{endPoint}"
        return! httpClient.GetFromJsonAsync<ExampleDto>(endPoint, jsonSerializerOptions).ConfigureAwait false
    }

    interface IProjectName with
        member this.ExampleMethod() = ValueTask<_>(task = this.ExampleMethod())

[<Extension; AbstractClass>]
type DependencyInjectionExtensions() =

    [<Extension>]
    static member AddDiscriminatedUnionsHttpClient(services: IServiceCollection) =
        services.AddHttpClient<IProjectName, ProjectNameVersion1HttpClient>() |> ignore
        services