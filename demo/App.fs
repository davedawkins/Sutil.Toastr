module App

// Copyright (c) 2018 Zaid Ajaj, 2022 David Dawkins

open Sutil
open Sutil.Toastr

open Fable.Core

[<Emit("console.log($0)")>]
let log (x: 'a) : unit = jsNative

type Model = string

let init() = "Elmish.Toastr", Cmd.none

type Message =
    | Success
    | Info
    | Error
    | Clicked
    | Warning
    | SimpleMsg
    | SimpleMsgWithTitle
    | SimpleProgressBar
    | Timeout
    | Interactive
    | ClearAll
    | RemoveAll
    | CloseButton
    | CloseButtonClicked

let update msg model =
    match msg with
    | Success ->
        let cmd =
          Toastr.message "Your account is created"
          |> Toastr.title "Shiny title"
          |> Toastr.position TopRight
          |> Toastr.timeout 3000
          |> Toastr.withProgressBar
          |> Toastr.hideEasing Easing.Swing
          |> Toastr.showCloseButton
          |> Toastr.onClick Clicked
          |> Toastr.success

        model, cmd

    | Info ->
        let cmd =
          Toastr.message "Just letting you know that you your account was blocked"
          |> Toastr.title "FYI"
          |> Toastr.position TopRight
          |> Toastr.timeout 3000
          |> Toastr.withProgressBar
          |> Toastr.hideEasing Easing.Swing
          |> Toastr.showCloseButton
          |> Toastr.info

        model, cmd

    | Error ->
        let cmd =
          Toastr.message "Oeps! Something went wrong"
          |> Toastr.title "So Sad!"
          |> Toastr.position TopRight
          |> Toastr.timeout 3000
          |> Toastr.withProgressBar
          |> Toastr.hideEasing Easing.Swing
          |> Toastr.showCloseButton
          |> Toastr.error

        model, cmd

    | ClearAll ->
        model, Toastr.clearAll

    | RemoveAll ->
        model, Toastr.removeAll

    | Warning ->
        let cmd =
          Toastr.message "Something is about to go down..."
          |> Toastr.title "Heads up"
          |> Toastr.position TopRight
          |> Toastr.timeout 3000
          |> Toastr.withProgressBar
          |> Toastr.hideEasing Easing.Swing
          |> Toastr.showCloseButton
          |> Toastr.warning

        model, cmd
    | SimpleMsg ->
        let cmd =
            Toastr.message "Your account is created"
            |> Toastr.success
        model, cmd

    | SimpleMsgWithTitle ->
        let cmd =
            Toastr.message "Your accound is created"
            |> Toastr.title "Server"
            |> Toastr.success
        model, cmd

    | SimpleProgressBar ->
        let cmd =
            Toastr.message "Countdown has started"
            |> Toastr.title "Be aware"
            |> Toastr.withProgressBar
            |> Toastr.warning
        model, cmd

    | Timeout ->
        let cmd =
            Toastr.message "Hide message in 5 seconds."
            |> Toastr.title "Delayed"
            |> Toastr.timeout 5000
            |> Toastr.withProgressBar
            |> Toastr.info

        model, cmd
    | CloseButton ->
        let cmd =
            Toastr.message "I have a close button"
            |> Toastr.title "Close"
            |> Toastr.showCloseButton
            |> Toastr.closeButtonClicked CloseButtonClicked
            |> Toastr.error
        model, cmd

    | CloseButtonClicked ->
        let cmd =
            Toastr.message "You clicked the close button"
            |> Toastr.title "Close Clicked"
            |> Toastr.info
        model, cmd

    | Interactive ->
        let cmd =
            Toastr.message "Click me to dispatch 'Clicked' message"
            |> Toastr.title "Click Me"
            |> Toastr.onClick Clicked
            |> Toastr.info

        model, cmd


    | Clicked ->
        let cmd =
            Toastr.message "I was summoned by a message"
            |> Toastr.title "Clicked"
            |> Toastr.info

        model, cmd




let simpleMessage = """
Toastr.message "Your account is created."
|> Toastr.success
"""

let simpleMsgTitle = """
Toastr.message "Your accound is created"
|> Toastr.title "Server"
|> Toastr.success
"""

let simpleProgressBar = """
Toastr.message "Countdown has started"
|> Toastr.title "Be aware"
|> Toastr.withProgressBar
|> Toastr.warning
"""

let timeoutSample = """
Toastr.message "Hide message in 5 seconds."
|> Toastr.title "Delayed"
|> Toastr.timeout 5000
|> Toastr.withProgressBar
|> Toastr.info
"""
let closeButtonSample = """
Toastr.message "I have a close button"
|> Toastr.title "Close"
|> Toastr.showCloseButton
|> Toastr.error
"""
let interactive = """
| Interactive ->
    let cmd =
        Toastr.message "Click me to dispatch 'Clicked' message"
        |> Toastr.title "Click Me"
        |> Toastr.onClick Clicked
        |> Toastr.info
    model, cmd

| Clicked ->
    let cmd =
        Toastr.message "I was summoned by a message"
        |> Toastr.title "Clicked"
        |> Toastr.info
    model, cmd
"""

let view () =

    let model, dispatch = () |> Store.makeElmish init update ignore

    let sample title snippet msg =
       let btn =
        Html.button [
            Attr.style [ Css.marginLeft 20 ]
            Attr.className "btn btn-info"
            Ev.onClick (fun _ -> dispatch msg)
            text "Run"
        ]

       Html.div [
            Attr.style [ Css.textAlignLeft; Css.displayTable; Css.custom( "margin", "0 auto") ]
            Html.h4 [ text title; Html.span [ btn ] ]
            Html.pre
                 [ Html.code
                        [ text snippet ] ] ]

    let spacing = Attr.style [Css.margin 5]

    Html.div [
        Attr.style [ Css.textAlignCenter ]
        Html.h1 [ text "Sutil.Toastr" ]

        Html.button [
            spacing; Attr.className "btn btn-success"; Ev.onClick (fun _ -> dispatch Success)
            text "Success" ]

        Html.button [
            spacing; Attr.className "btn btn-info";Ev.onClick (fun _ -> dispatch Info)
            text "Info" ]

        Html.button [
            spacing; Attr.className "btn btn-warning";Ev.onClick (fun _ -> dispatch Warning)
            text "Warning" ]

        Html.button [
            spacing; Attr.className "btn btn-danger"; Ev.onClick (fun _ -> dispatch Error)
            text "Error" ]

        Html.button [
            spacing; Attr.className "btn btn-primary"; Ev.onClick (fun _ -> dispatch RemoveAll)
            text "Remove All" ]

        Html.button [
            spacing; Attr.className "btn btn-primary"; Ev.onClick (fun _ -> dispatch ClearAll)
            text "Clear All" ]

        Html.br []
        Html.hr [ ]
        sample "Simple message" simpleMessage SimpleMsg
        Html.hr [ ]
        sample "Message with title" simpleMsgTitle SimpleMsgWithTitle
        Html.hr [ ]
        sample "Progress bar" simpleProgressBar SimpleProgressBar
        Html.hr [ ]
        sample "Close Button" closeButtonSample CloseButton
        Html.hr [ ]
        sample "Timeout" timeoutSample Timeout
        Html.hr [ ]
        sample "Interactive" interactive Interactive
        Html.hr [ ]
    ]


view() |> Program.mountElement "sutil-app"