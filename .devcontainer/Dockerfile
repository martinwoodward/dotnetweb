# Lock to dotnet core 3.1
FROM mcr.microsoft.com/dotnet/core/sdk:3.1

# This Dockerfile adds a non-root user with sudo access. Use the "remoteUser"
# property in devcontainer.json to use it. On Linux, the container user's GID/UIDs
# will be updated to match your local UID/GID (when using the dockerFile property).
# See https://aka.ms/vscode-remote/containers/non-root-user for details.
ARG USERNAME=vscode
ARG USER_UID=1000
ARG USER_GID=$USER_UID

# Version of Node.js to install.
ARG INSTALL_NODE="true"
ARG NODE_VERSION="lts/*"
ENV NVM_DIR=/usr/local/share/nvm

# Install the Azure CLI
ARG INSTALL_AZURE_CLI="true"

WORKDIR /home/

COPY . .

RUN bash ./setup.sh
