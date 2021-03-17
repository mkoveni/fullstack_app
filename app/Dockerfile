FROM node:12.16.2 as build-stage
WORKDIR /app
COPY package*.json /app/
RUN npm install
COPY ./ /app/

RUN npm run build


FROM nginx:1.17.10

COPY --from=build-stage /app/dist/ /usr/share/nginx/html

COPY ./nginx-custom.conf /etc/nginx/conf.d/default.conf