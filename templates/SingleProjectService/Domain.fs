namespace ProjectName.Domain

type Example = {
    Value: int
}

module Example =
    let makeObj() = {
        Example.Value = 10
    }