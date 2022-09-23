FROM node:16.17 as build
WORKDIR /dist/src/app

RUN npm i -g npm@8.19.1
COPY package*.json ./
RUN npm i
COPY . .
RUN npm run build

FROM nginx:1.21.3-alpine as final
COPY --from=build /dist/src/app/dist/playlists /usr/share/nginx/html
COPY /nginx.conf /etc/nginx/conf.d/default.conf
EXPOSE 80
