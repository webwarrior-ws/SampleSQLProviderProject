open System

open FSharp.Data.Sql

[<Literal>]
let DevelopmentConnStr =
    "Server=localhost;Port=5432;Database=test;User Id=postgres;Password='localDevPassword'"

type SQL =
    SqlDataProvider<Common.DatabaseProviderTypes.POSTGRESQL, DevelopmentConnStr, Owner="public, admin, references", UseOptionTypes=Common.NullableColumnType.OPTION>

let ctx =
    typeof<Npgsql.NpgsqlConnection>.Assembly |> ignore
    SQL.GetDataContext DevelopmentConnStr

let testRecord = ctx.Public.Test.Create()
testRecord.String <- "test"
testRecord.Datetime <- DateTime.Now
ctx.SubmitUpdates()