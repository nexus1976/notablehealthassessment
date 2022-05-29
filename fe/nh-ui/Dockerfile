FROM node:latest as node
WORKDIR /app
COPY . .
RUN npm ci
RUN npm run build

FROM nginx:alpine
EXPOSE 80
COPY nginx.conf /etc/nginx/nginx.conf
COPY --from=node /app/dist/nh-ui /usr/share/nginx/html
