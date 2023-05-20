export default class ConnectionFactory {
    static environmentMapper = {
        "local": "https://localhost:7246",
        "prod": "......"
    }

    static environment = process.env.ENVIRONMENT

    static getCioccEventEndpointUrl() {
        return ConnectionFactory.environmentMapper[ConnectionFactory.environment] + "/api/ciocc/event"
    }
}
