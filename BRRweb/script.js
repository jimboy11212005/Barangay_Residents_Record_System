// ✅ Universal API Helper - Fixes ALL "Failed to Fetch" errors
const API_BASE = 'http://localhost:7283/api'; // Your API port

async function apiRequest(endpoint, options = {}) {
    const token = localStorage.getItem('token');
    
    const config = {
        headers: {
            'Content-Type': 'application/json',
            ...(token && { 'Authorization': `Bearer ${token}` })
        },
        ...options
    };

    // Try both HTTP and HTTPS
    const urls = [
        `${API_BASE}${endpoint}`,
        `https://localhost:7283${endpoint}`
    ];

    for (const url of urls) {
        try {
            console.log(`API Request: ${url}`);
            const response = await fetch(url, config);
            
            if (response.ok) return response;
            
            // Handle 401 Unauthorized
            if (response.status === 401) {
                localStorage.clear();
                window.location.href = 'index.html';
                throw new Error('Session expired. Please login again.');
            }
        } catch (error) {
            console.log(`Failed ${url}:`, error.message);
            continue;
        }
    }
    
    throw new Error('API unavailable. Check if server is running on port 7283');
}

function logout() {
    localStorage.clear();
    window.location.href = 'index.html';
}

function showMessage(elementId, message, type = 'info') {
    const el = document.getElementById(elementId);
    el.innerHTML = `<div class="alert alert-${type} alert-dismissible fade show" role="alert">
        ${message}
        <button type="button" class="btn-close" data-bs-dismiss="alert"></button>
    </div>`;
}