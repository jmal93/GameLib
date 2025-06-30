FROM node:lts-alpine

# Modo desenvolvimento
ENV NODE_ENV=development

WORKDIR /usr/src/app

# Copy package files
COPY ["package.json", "package-lock.json*", "npm-shrinkwrap.json*", "./"]

# Install ALL dependencies (including devDependencies)
RUN npm install --silent

# Copy source code
COPY . .

# Expose port
EXPOSE 3000

# Change ownership
RUN chown -R node /usr/src/app
USER node

# Run in development mode (reads env vars at runtime)
CMD ["npm", "run", "dev"]