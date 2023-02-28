# 1.0.11
- Include "*.fs" not "**\*.fs", since path in pkg is then "fable\\Toastr.fs" and this seems to be upsetting SourceLine ("contains untracked sources")

# 1.0.10
- Make sure project clean before publishing package, or SourceLink complains "untracked sources: obj"

# 1.0.9
- Copied package configuration detaails from Fable.Promise. Snupkg and SourceLink now identical to that package

# 1.0.8
- Corrected fsproj with SourceLink

# 1.0.7
- Enable SourceLink

# 1.0.6
- Fix some dependencies for Sutil and fable publish utils

# 1.0.5
- Updated to Sutil 2.x

# 1.0.4
- Pinned to .NET6
-
# 1.0.3
- Initial release. Port of Zaid's `Elmish.Toastr`, a wrapper for `toastr`
