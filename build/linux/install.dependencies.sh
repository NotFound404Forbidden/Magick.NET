#!/bin/bash
set -e

apt-get update

apt-get install fontconfig unzip -y

git clone https://github.com/ImageMagick/msttcorefonts msttcorefonts
cd msttcorefonts
. ./install.sh

fc-cache
