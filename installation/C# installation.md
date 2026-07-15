# Setting Up .NET / C# on Linux (Fedora)

A guide for getting the .NET SDK working reliably on Fedora, avoiding the package-manager pitfalls that cause the most common setup headaches.

## TL;DR

Use Microsoft's install script, not `dnf`. It installs into your home directory, avoids Fedora's split-package versioning issues, and matches what you'd do on any other distro.

```bash
cd ~
curl -L https://dot.net/v1/dotnet-install.sh -o dotnet-install.sh
chmod +x ./dotnet-install.sh
./dotnet-install.sh --channel 8.0
```

Then add it to your `PATH` permanently:

```bash
echo 'export DOTNET_ROOT=$HOME/.dotnet' >> ~/.bashrc
echo 'export PATH=$PATH:$HOME/.dotnet' >> ~/.bashrc
source ~/.bashrc
```

Verify:

```bash
dotnet --version
dotnet --list-sdks
```

## Why not just `dnf install dotnet-sdk-8.0`?

Fedora splits the SDK across several interdependent rpm packages: `dotnet-host`, `dotnet-hostfxr`, `dotnet-sdk`, `dotnet-runtime`. These can silently drift out of sync with each other (e.g. `dotnet-host` gets pulled to v10 by some other dependency while `dotnet-sdk` stays on v8), which breaks the resolver with errors like:

```
Error: [/usr/lib64/dotnet/host/fxr] does not contain any version-numbered child folders
```

or

```
The application '--version' does not exist.
```

The script-based install avoids this entirely by keeping everything self-contained under `~/.dotnet`.

### If you've already got a broken `dnf` install

Clean it out before switching to the script method:

```bash
sudo dnf remove 'dotnet*'
sudo rm -f /usr/bin/dotnet
sudo rm -rf /usr/lib64/dotnet
hash -r          # clear bash's cached path to the old binary
```

Then follow the script install steps above.

## Choosing a version

- `--channel 8.0` — LTS, supported until Nov 2026, matches most course material and tutorials
- `--channel latest` (or omit `--channel`) — grabs whatever the script currently calls "latest LTS" (as of mid-2026, this is .NET 10)
- Multiple SDKs can coexist under `~/.dotnet/sdk` — install more than one if you need to match a specific course version:
  ```bash
  ./dotnet-install.sh --channel 8.0
  ./dotnet-install.sh --channel 10.0
  ```

## Day-to-day: creating and running files

**Quick single-file exercises** (requires .NET 10+):

```bash
touch exercise.cs
# write top-level statements, no Main() wrapper needed
dotnet run exercise.cs
```

Each file runs independently — no shared project, so no collision between multiple `Main()`s.

**Real multi-file projects:**

```bash
mkdir ProjectName && cd ProjectName
dotnet new console
dotnet run
```

Everything in that folder compiles together into one program via the generated `.csproj` — this is what you want once a program spans more than one file.

> ⚠️ Don't mix the two patterns in the same folder: a project's `.csproj` compiles every `.cs` file in the directory together, so a leftover single-file exercise with its own top-level statements will collide with the project's entry point.

## Editor / IDE options on Linux

| Option | Notes |
|---|---|
| **VS Code** + C# Dev Kit extension | Lightweight, good if you want one editor across all languages. IntelliSense, debugging, test running. |
| **JetBrains Rider** | Free for non-commercial/educational use (and free via JetBrains' student program). Closest experience to Visual Studio's refactoring/debugging UI — useful if your instructor is on Visual Studio. Strong built-in database tooling, handy for EF Core / SQL Server work. |
| Visual Studio (proper) | Windows/Mac only — not available on Linux. |

## Troubleshooting checklist

If `dotnet --version` fails after install:

```bash
which dotnet                 # is it resolving to ~/.dotnet/dotnet or something else?
rpm -qa | grep dotnet        # any leftover dnf packages still installed?
grep -n "dotnet" ~/.bashrc   # did the PATH export actually get written?
echo $PATH                   # is ~/.dotnet actually present in the resolved PATH?
```

Open a **fresh terminal** after editing `.bashrc` — some terminal setups read `.bash_profile` on login instead, so a `source` in an existing session doesn't always pick up new exports.