export const CONFIG = {
    scenarios: {
        default: {
            executor: 'ramping-vus',
            startVUs: 1,
            stages: [
                { duration: '30s', target: 5 },   // Ramp up
                { duration: '1m', target: 5 },    // Stay steady
                { duration: '30s', target: 0 }    // Ramp down
            ]
        }
    }
};

export const TEST_CONFIG = {
    thresholds: {
        http_req_failed: ['rate<0.1'],      // Allow 10% errors
        http_req_duration: ['p(95)<2000'],  // 95% of requests under 2s
        iteration_duration: ['p(95)<3000']   // 95% of iterations under 3s
    }
};

export const API_BASE_URL = 'http://localhost:5079/api';

export const HEADERS = {
    'Content-Type': 'application/json',
    'Accept': 'application/json'
};