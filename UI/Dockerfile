FROM nginx:alpine as base
WORKDIR /app
EXPOSE 80 443

FROM johnpapa/angular-cli as build
WORKDIR /src
COPY package.json ./
RUN npm install --silent
COPY . .
RUN ng build --prod --build-optimizer

FROM base AS final
COPY --from=build /src/dist/notes /usr/share/nginx/html
CMD [ "nginx", "-g", "daemon off;"]
