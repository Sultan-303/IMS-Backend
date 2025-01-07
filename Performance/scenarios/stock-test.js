import { CONFIG } from '../config/test-config.js';
import { TEST_DATA } from '../data/test-data.js';
import http from 'k6/http';
import { check, group, sleep } from 'k6';
import { Rate } from 'k6/metrics';

const errorRate = new Rate('errors');
export const options = CONFIG;

export default function() {
    group('Stock API Tests', () => {
        // GET all stock
        group('Get All Stock', () => {
            const response = http.get(`${CONFIG.baseUrl}/stock`);
            check(response, {
                'status is 200': (r) => r.status === 200,
                'response time < 200ms': (r) => r.timings.duration < 200
            }) || errorRate.add(1);
        });

        // POST new stock
        group('Create Stock', () => {
            const payload = JSON.stringify(TEST_DATA.stock.valid.create);
            const response = http.post(
                `${CONFIG.baseUrl}/stock`,
                payload,
                { headers: CONFIG.params.headers }
            );
            check(response, {
                'status is 201': (r) => r.status === 201,
                'response time < 300ms': (r) => r.timings.duration < 300
            }) || errorRate.add(1);
        });

        sleep(1);
    });
}