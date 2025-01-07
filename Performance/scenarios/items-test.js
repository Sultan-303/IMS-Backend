import { CONFIG, TEST_CONFIG, API_BASE_URL, HEADERS } from '../config/test-config.js';
import { TEST_DATA } from '../data/test-data.js';
import http from 'k6/http';
import { check, group, sleep } from 'k6';
import { Rate } from 'k6/metrics';

const errorRate = new Rate('errors');

export const options = {
    scenarios: CONFIG.scenarios,
    thresholds: TEST_CONFIG.thresholds
};

export default function() {
    group('Items API Tests', () => {
        const params = { headers: HEADERS };

        group('Get All Items', () => {
            const response = http.get(`${API_BASE_URL}/items`, params);
            check(response, {
                'status is 200': (r) => r.status === 200,
                'response time < 2000ms': (r) => r.timings.duration < 2000,
            });
        });

        sleep(1);
    });
}