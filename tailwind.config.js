/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    './**/*.{razor,html,cshtml}',
    './Components/**/*.{razor,html}',
    './Pages/**/*.{razor,html}'
  ],
  corePlugins: {
    preflight: false,
  },
  theme: {
    extend: {
      colors: {
        primary: {
          DEFAULT: '#1E88E5',
          dark: '#1565C0',
          hover: '#1976D2',
          light: '#E3F2FD',
        },
        secondary: {
          DEFAULT: '#26A69A',
          dark: '#00897B',
          light: '#E0F2F1',
        },
        surface: '#FFFFFF',
        background: '#F5F7FB',
        danger: {
          DEFAULT: '#E53935',
          dark: '#C62828',
          light: '#FFEBEE',
        },
        success: {
          DEFAULT: '#2E7D32',
          light: '#E8F5E9',
        },
        reconnect: {
          blue: '#6b9ed2',
          'blue-dark': '#3b6ea2',
          pulse: '#0087ff',
        },
      },
      boxShadow: {
        'error-bar': '0 -1px 2px rgba(0, 0, 0, 0.2)',
        'modal-elevated': '0 3px 6px 2px rgba(0, 0, 0, 0.3)',
      },
      fontFamily: {
        sans: ['Roboto', 'Helvetica Neue', 'Helvetica', 'Arial', 'sans-serif'],
      },
      keyframes: {
        'reconnect-slide-up': {
          '0%': { transform: 'translateY(30px) scale(0.95)' },
          '100%': { transform: 'translateY(0) scale(1)' },
        },
        'reconnect-fade-in': {
          '0%': { opacity: '0' },
          '100%': { opacity: '1' },
        },
        'reconnect-fade-out': {
          '0%': { opacity: '1' },
          '100%': { opacity: '0' },
        },
        'reconnect-pulse-ring': {
          '0%': { top: '40px', left: '40px', width: '0', height: '0', opacity: '0' },
          '5%': { top: '40px', left: '40px', width: '0', height: '0', opacity: '1' },
          '100%': { top: '0px', left: '0px', width: '80px', height: '80px', opacity: '0' },
        },
      },
      animation: {
        'reconnect-slide-up': 'reconnect-slide-up 1.5s cubic-bezier(.05, .89, .25, 1.02) 0.3s both',
        'reconnect-fade-in': 'reconnect-fade-in 0.5s ease-in-out 0.3s both',
        'reconnect-fade-out': 'reconnect-fade-out 0.5s both',
        'reconnect-pulse': 'reconnect-pulse-ring 1.5s cubic-bezier(0, 0.2, 0.8, 1) infinite',
      },
    },
  },
  plugins: [],
};
