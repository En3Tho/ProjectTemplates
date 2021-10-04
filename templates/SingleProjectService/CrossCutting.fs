namespace ProjectName.CrossCutting

open ProjectName.Contracts.Version1
open ProjectName.Domain

module Example =
    let toDto (example: Example) : ExampleDto = {
        Value = example.Value
    }

    let fromDto (example: ExampleDto) : Example = {
        Value = example.Value
    }