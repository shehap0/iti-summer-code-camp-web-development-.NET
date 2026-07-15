if u are like me on linux(fedora) here how did i get it to work

**1. Install a container engine**

Fedora ships with Podman by default (Docker-compatible commands), or you can install Docker:

```bash
# Podman (already there usually, or install it)
sudo dnf install podman -y

# OR Docker
sudo dnf install docker -y
sudo systemctl enable --now docker
sudo usermod -aG docker $USER   # avoid needing sudo every time, then re-login
```

I'd just use whichever is already installed — commands are identical, just swap `docker` for `podman`.

**2. Pull and run SQL Server 2022**

```bash
docker pull mcr.microsoft.com/mssql/server:2022-latest

docker run -e "ACCEPT_EULA=Y" \
  -e "MSSQL_SA_PASSWORD=YourStr0ng!Passw0rd" \
  -p 1433:1433 --name sql1 --hostname sql1 \
  -v sql1_data:/var/opt/mssql \
  -d mcr.microsoft.com/mssql/server:2022-latest
```

- `-v sql1_data:/var/opt/mssql` gives you a named volume so your data survives if you remove/recreate the container.
- Password needs 8+ chars, upper+lower+number+symbol or it'll refuse to start — check with `docker logs sql1` if it exits immediately.

**3. Verify it's running**

```bash
docker ps
```

**4. Connect to it**

Options, from easiest to most GUI:

- **sqlcmd inside the container** (no extra install needed):
```bash
docker exec -it sql1 /opt/mssql-tools18/bin/sqlcmd -S localhost -U SA -P 'YourStr0ng!Passw0rd' -C
```
- **VS Code** with the "SQL Server (mssql)" extension — probably your best bet since you're in a .NET track anyway and likely living in VS Code.

**Day-to-day commands you'll want:**
```bash
docker stop sql1     # stop it
docker start sql1     # start it again later
docker logs sql1      # debug if it won't connect
```

One thing worth flagging: don't `docker rm` the container without the volume in place, or you lose your databases. As long as `sql1_data` volume exists, you can freely recreate the container.
