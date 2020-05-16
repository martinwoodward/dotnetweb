# set noninteractive installation
export DEBIAN_FRONTEND=noninteractive

## update and install some things we should probably have
apt-get update

apt-get -y install --no-install-recommends apt-utils dialog 2>&1


apt-get install -y \
  curl \
  git \
  gnupg2 \
  jq \
  sudo \
  tzdata \
  openssh-client \
  less \
  iproute2 \
  procps \
  apt-transport-https \
  gnupg2 \
  lsb-release

# set your timezone
ln -fs /usr/share/zoneinfo/UCT /etc/localtime
#ln -fs /usr/share/zoneinfo/GB /etc/localtime
dpkg-reconfigure --frontend noninteractive tzdata

# Create a non-root user to use if preferred - see https://aka.ms/vscode-remote/containers/non-root-user.
groupadd --gid $USER_GID $USERNAME
useradd -s /bin/bash --uid $USER_UID --gid $USER_GID -m $USERNAME
echo $USERNAME ALL=\(root\) NOPASSWD:ALL > /etc/sudoers.d/$USERNAME
chmod 0440 /etc/sudoers.d/$USERNAME
if [ "$INSTALL_NODE" = "true" ]
then
  #
  # Install nvm and Node
  mkdir -p ${NVM_DIR}
  curl -so- https://raw.githubusercontent.com/nvm-sh/nvm/v0.35.3/install.sh | bash 2>&1
  chown -R ${USER_UID}:${USER_GID} ${NVM_DIR}
  /bin/bash -c "source $NVM_DIR/nvm.sh \
      && nvm alias default ${NODE_VERSION}" 2>&1
  echo '[ -s "$NVM_DIR/nvm.sh" ] && \\. "$NVM_DIR/nvm.sh"  && [ -s "$NVM_DIR/bash_completion" ] && \\. "$NVM_DIR/bash_completion"' | tee -a /home/${USERNAME}/.bashrc /home/${USERNAME}/.zshrc >> /root/.zshrc
  echo "if [ \"\$(stat -c '%U' ${NVM_DIR})\" != \"${USERNAME}\" ]; then sudo chown -R ${USER_UID}:root ${NVM_DIR}; fi" | tee -a /root/.bashrc /root/.zshrc /home/${USERNAME}/.bashrc >> /home/${USERNAME}/.zshrc
  chown ${USER_UID}:${USER_GID} /home/${USERNAME}/.bashrc /home/${USERNAME}/.zshrc
  chown -R ${USER_UID}:root ${NVM_DIR}
  #
  # Install yarn
  curl -sS https://dl.yarnpkg.com/$(lsb_release -is | tr '[:upper:]' '[:lower:]')/pubkey.gpg | apt-key add - 2>/dev/null
  echo "deb https://dl.yarnpkg.com/$(lsb_release -is | tr '[:upper:]' '[:lower:]')/ stable main" | tee /etc/apt/sources.list.d/yarn.list
  apt-get update
  apt-get -y install --no-install-recommends yarn;
fi

if [ "$INSTALL_AZURE_CLI" = "true" ]
then
    echo "deb [arch=amd64] https://packages.microsoft.com/repos/azure-cli/ $(lsb_release -cs) main" > /etc/apt/sources.list.d/azure-cli.list
    curl -sL https://packages.microsoft.com/keys/microsoft.asc | apt-key add - 2>/dev/null
    apt-get update
    apt-get install -y azure-cli;
fi

apt-get autoremove -y
apt-get autoremove -y
rm -rf /var/lib/apt/lists/*
