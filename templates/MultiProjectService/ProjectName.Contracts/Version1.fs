module ProjectName.Contracts.Version1

open System.Threading.Tasks

let [<Literal>] Version = "v1"

module Routes =
    let [<Literal>] Controller = "example-service" + "/" + Version + "/"
    let [<Literal>] ExampleMethod = "example-method"

module Endpoints =
    let [<Literal>] ExampleMethod = Routes.Controller + Routes.ExampleMethod

type ExampleDto = {
    Value: int
}

type IProjectName =
    abstract ExampleMethod: unit -> ValueTask<ExampleDto>