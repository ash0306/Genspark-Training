FROM node:alpine

WORKDIR /app

COPY package.json /app

RUN npm install

COPY . /app

EXPOSE 3231

CMD ["npm", "run", "dev"]